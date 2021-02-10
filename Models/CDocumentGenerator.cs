using NPOI.OpenXmlFormats.Wordprocessing;
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
			table.Width = 5500;

			XWPFTableRow tableRowOne = table.GetRow(0);
			tableRowOne.GetCell(0).SetText("AIR WAYBILL NUMBER");
			tableRowOne.AddNewTableCell().SetText("NR OF PACK");
			tableRowOne.AddNewTableCell().SetText("NATURE OF GODS");
			tableRowOne.AddNewTableCell().SetText("CROSS WEIGHT");
			tableRowOne.AddNewTableCell().SetText("ORIGIN DEST");
			tableRowOne.AddNewTableCell().SetText("FOR OFFICIAL USE ONLY");
			tableRowOne.AddNewTableCell().SetText("REMARK");
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
			LastRun.SetText("ULD TOTAL");
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
				newPar.Alignment = ParagraphAlignment.RIGHT;
				XWPFRun parRun = newPar.CreateRun();
				parRun.SetText(manifest.Cargos[i].Weight + "KG");
				SumWeight += manifest.Cargos[i].Weight;
			}
			XWPFParagraph CellLastPar = tableCell.AddParagraph();
			CellLastPar.Alignment = ParagraphAlignment.RIGHT;
			XWPFRun CellLastRun = CellLastPar.CreateRun();
			CellLastRun.SetText(SumWeight + "KG");
		}

		public bool GenDoc(CManifest manifest, CFlight flight, DateTime date)
		{
			try {
				//Create document
				XWPFDocument doc = new XWPFDocument();

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


				doc.Document.body.sectPr = new CT_SectPr();
				CT_SectPr secPr = doc.Document.body.sectPr;

				//Create header and set its text
				CT_Hdr header = new CT_Hdr();
				header.AddNewP().AddNewR().AddNewT().Value = "CARGO MANIFEST";
				//Create footer and set its text
				CT_Ftr footer = new CT_Ftr();
				string Footer = "___________________________________________________________________________\n"
					+ "Средства пакетирования загружены на борт..."
					+ "Старший на рейсе ВМТС-грузчик ____________________(подпись) __________ (ФИО)_________(дата)\n";
				footer.AddNewP().AddNewR().AddNewT().Value = Footer;
				//Create the relation of header
				XWPFRelation relation1 = XWPFRelation.HEADER;
				XWPFHeader myHeader = (XWPFHeader)doc.CreateRelationship(relation1, XWPFFactory.GetInstance(), doc.HeaderList.Count + 1);
				//Create the relation of footer
				XWPFRelation relation2 = XWPFRelation.FOOTER;
				XWPFFooter myFooter = (XWPFFooter)doc.CreateRelationship(relation2, XWPFFactory.GetInstance(), doc.FooterList.Count + 1);
				//Set the header
				myHeader.SetHeaderFooter(header);
				CT_HdrFtrRef myHeaderRef = secPr.AddNewHeaderReference();
				myHeaderRef.type = ST_HdrFtr.@default;
				myHeaderRef.id = myHeader.GetPackageRelationship().Id;
				//Set the footer
				myFooter.SetHeaderFooter(footer);
				CT_HdrFtrRef myFooterRef = secPr.AddNewFooterReference();
				myFooterRef.type = ST_HdrFtr.@default;
				myFooterRef.id = myFooter.GetPackageRelationship().Id;
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
