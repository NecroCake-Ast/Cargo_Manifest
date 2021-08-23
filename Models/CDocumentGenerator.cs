using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.Model;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Practic_3_curs.Models
{
	public class CDocumentGenerator
	{
		void AddTableHeader(XWPFTable table)
		{
			XWPFTableRow Headers = table.GetRow(0);
			Headers.GetCell(0).SetText("AIR WAYBILL");
			XWPFParagraph paragraph = Headers.GetCell(0).AddParagraph();
			XWPFRun run = paragraph.CreateRun();
			run.SetText("NUMBER");
			Headers.AddNewTableCell().SetText("NR OF PACK");
			Headers.AddNewTableCell().SetText("NATURE OF GODS");
			Headers.AddNewTableCell().SetText("CROSS WEIGHT");
			Headers.AddNewTableCell().SetText("ORIGIN DEST");
			Headers.AddNewTableCell().SetText("FOR OFFICIAL USE ONLY");
			Headers.AddNewTableCell().SetText("REMARK\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0");
		}

		void AddWaybills(XWPFTableCell tableCol, CManifest manifest)
        {
			for (int i = 0; i < manifest.Cargos.Count; i++)
			{
				XWPFParagraph newPar = tableCol.AddParagraph();
				XWPFRun parRun = newPar.CreateRun();
				parRun.SetText(manifest.Cargos[i].Waybill.Code.ToString()
					+ "-" + manifest.Cargos[i].Waybill.Num.ToString());
			}
			XWPFParagraph LastPar = tableCol.AddParagraph();
			XWPFRun LastRun = LastPar.CreateRun();
			LastRun.SetText("TOTAL");
		}

		void AddPlaces(XWPFTableCell tableCol, CManifest manifest)
		{
			int SumPlace = 0;
			for (int i = 0; i < manifest.Cargos.Count; i++)
			{
				XWPFParagraph newPar = tableCol.AddParagraph();
				XWPFRun parRun = newPar.CreateRun();
				parRun.SetText(manifest.Cargos[i].PlaceCnt.ToString());
				SumPlace += manifest.Cargos[i].PlaceCnt;
			}
			XWPFParagraph LastPar = tableCol.AddParagraph();
			XWPFRun LastRun = LastPar.CreateRun();
			LastRun.SetText(SumPlace.ToString());
		}

		void AddCargoTypes(XWPFTableCell tableCol, CManifest manifest)
        {
			XWPFParagraph Header = tableCol.GetParagraphArray(0);
			XWPFRun HeaderWrite = Header.CreateRun();
			HeaderWrite.SetText("BULK");
			for (int i = 0; i < manifest.Cargos.Count; i++)
			{
				XWPFParagraph newPar = tableCol.AddParagraph();
				XWPFRun parRun = newPar.CreateRun();
				parRun.SetText(manifest.Cargos[i].Type.TrimEnd());
			}
		}

		void AddWeight(XWPFTableCell tableCell, CManifest manifest)
        {
			double SumWeight = 0;
			for (int i = 0; i < manifest.Cargos.Count; i++)
			{
				XWPFParagraph newPar = tableCell.AddParagraph();
				XWPFRun parRun = newPar.CreateRun();
				parRun.SetText(manifest.Cargos[i].Weight + "KG");
				SumWeight += manifest.Cargos[i].Weight;
			}
			XWPFParagraph CellLastPar = tableCell.AddParagraph();
			XWPFRun CellLastRun = CellLastPar.CreateRun();
			CellLastRun.SetText(SumWeight + "KG");
		}

		void AddHeader(XWPFDocument doc)
        {
			XWPFHeaderFooterPolicy policy = doc.CreateHeaderFooterPolicy();
			XWPFHeader header = policy.CreateHeader(ST_HdrFtr.@default);
			XWPFParagraph paragraph = header.CreateParagraph();
			paragraph.Alignment = ParagraphAlignment.CENTER;
			XWPFRun run = paragraph.CreateRun();
			run.SetText("CARGO MANIFEST");
		}

		void AddFooter(XWPFDocument doc)
		{
			XWPFHeaderFooterPolicy policy = doc.CreateHeaderFooterPolicy();
			XWPFFooter footer = policy.CreateFooter(ST_HdrFtr.@default);
			XWPFParagraph paragraph = footer.GetParagraphArray(0);
			XWPFRun run = paragraph.CreateRun();
			run.FontFamily = "Times New Roman";
			run.FontSize = 12;
			run.SetText("______________________________________________________________________________________________");
			paragraph = footer.CreateParagraph();
			run = paragraph.CreateRun();
			run.SetText("Средства пакетирования загружены на борт...");
			paragraph = footer.CreateParagraph();
			run = paragraph.CreateRun();
			run.SetText("Старший на рейсе ВМТС-грузчик ____________________(подпись) __________ (ФИО)_________(дата)");
		}

		public bool GenDoc(CManifest manifest, CFlight flight, DateTime date)
		{
			try {
				//Create document
				XWPFDocument doc = new XWPFDocument();
				doc.Document.body.AddNewSectPr();
				CT_SectPr sectPr = doc.Document.body.sectPr;

				AddHeader(doc);
				AddFooter(doc);

				// Отступы
				sectPr.pgMar.left = 284;
				sectPr.pgMar.right = 300;

				//Create info about manifest
				XWPFParagraph FIRSTLINE = doc.CreateParagraph();
				XWPFRun first = FIRSTLINE.CreateRun();
				first.SetText("OPERATOR");

				XWPFParagraph SECONDLINE = doc.CreateParagraph();
				XWPFRun second = SECONDLINE.CreateRun();
				second.SetText("AIRCRAFT " + manifest.Aircraft + "            FLIGHT " + manifest.Flight + "            DATE " + manifest.Date);

				XWPFParagraph THIRDLINE = doc.CreateParagraph();
				XWPFRun third = THIRDLINE.CreateRun();
				third.SetText("FROM " + manifest.From + "                TO " + manifest.To + "                          docdocdocdocdocdoc");

				//create table
				XWPFTable table = doc.CreateTable();

				//create first row
				AddTableHeader(table);
				//create second row
				XWPFTableRow tableRowTwo = table.CreateRow();
				AddWaybills(tableRowTwo.GetCell(0), manifest);
				AddPlaces(tableRowTwo.GetCell(1), manifest);
				AddCargoTypes(tableRowTwo.GetCell(2), manifest);
				AddWeight(tableRowTwo.GetCell(3), manifest);

				
				for (int i = 0; i < manifest.Cargos.Count; i++)
				{
					XWPFParagraph newPar = tableRowTwo.GetCell(4).AddParagraph();
					XWPFRun parRun = newPar.CreateRun();
					parRun.SetText(manifest.From.TrimEnd() + "-" + manifest.To.TrimEnd());
				}

				//create third row
				XWPFTableRow tableRowThree = table.CreateRow();
				tableRowThree.GetCell(0).SetText("                  ");
				tableRowThree.GetCell(1).SetText("                  ");
				tableRowThree.GetCell(2).SetText("                  ");

				//Save the file
				using (FileStream stream = File.Create(date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx"))
				{
					doc.Write(stream);
				}
				return true;
			}
			catch {
				
			}
			return false;
		}
	}
}
