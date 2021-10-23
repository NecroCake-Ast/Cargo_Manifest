#include "airporteditpage.h"
#include "ui_airporteditpage.h"
#include "Services/servicelist.h"

#include <QMessageBox>

AirportEditPage::AirportEditPage(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::AirportEditPage)
{
    ui->setupUi(this);
    m_airports = ServiceList::getAirportRepository();
}

AirportEditPage::~AirportEditPage()
{
    delete ui;
}

void AirportEditPage::setActive(int64_t airportID)
{
    m_activeAirport = m_airports->Get(airportID);
    ui->enNamePlace->setText(QString::fromStdString(m_activeAirport.getEnName()));
    ui->ruNamePlace->setText(QString::fromStdString(m_activeAirport.getRuName()));
    ui->enName_inp->clear();
    ui->ruName_inp->clear();
}

void AirportEditPage::on_remove_btn_clicked()
{
    QMessageBox msgBox;
    msgBox.setText(QString::fromStdString("Вы действительно хотите даные об аэропорте ") + ui->ruNamePlace->text() + "?");
    msgBox.setStandardButtons(QMessageBox::Yes | QMessageBox::No);
    msgBox.setDefaultButton(QMessageBox::No);
    if (msgBox.exec() == QMessageBox::Yes) {
        m_airports->Remove(m_activeAirport.getID());
        emit removed();
    }
}

void AirportEditPage::on_enUpdate_btn_clicked()
{
    QString str = ui->enName_inp->text().toUpper();
    if (str.size() > 0) {
        QMessageBox msgBox;
        QString msgHeader = QString::fromStdString("Изменить английское название с ")
                + m_activeAirport.getEnName().c_str() + " на " + str + "?";
        msgBox.setText(msgHeader);
        msgBox.setStandardButtons(QMessageBox::Yes | QMessageBox::No);
        msgBox.setDefaultButton(QMessageBox::No);
        if (msgBox.exec() == QMessageBox::Yes) {
            m_activeAirport.setEnName(str.toStdString());
            ui->enNamePlace->setText(str);
            ui->enName_inp->clear();
            m_airports->Update(m_activeAirport);
        }
    }
}

void AirportEditPage::on_ruUpdate_btn_clicked()
{
    QString str = ui->ruName_inp->text().toUpper();
    if (str.size() > 0) {
        QMessageBox msgBox;
        QString msgHeader = QString::fromStdString("Изменить русское название с ")
                + m_activeAirport.getRuName().c_str() + " на " + str + "?";
        msgBox.setText(msgHeader);
        msgBox.setStandardButtons(QMessageBox::Yes | QMessageBox::No);
        msgBox.setDefaultButton(QMessageBox::No);
        if (msgBox.exec() == QMessageBox::Yes) {
            m_activeAirport.setRuName(str.toStdString());
            ui->ruNamePlace->setText(str);
            ui->ruName_inp->clear();
            m_airports->Update(m_activeAirport);
        }
    }
}

