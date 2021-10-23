#include "airportaddpage.h"
#include "ui_airportaddpage.h"
#include "Services/servicelist.h"

#include <QMessageBox>

AirportAddPage::AirportAddPage(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::AirportAddPage)
{
    ui->setupUi(this);
    m_airports = ServiceList::getAirportRepository();
}

AirportAddPage::~AirportAddPage()
{
    delete ui;
}


void AirportAddPage::on_add_btn_clicked()
{
    std::string ruName = ui->ruName_inp->text().toUpper().toStdString();
    std::string enName = ui->enName_inp->text().toUpper().toStdString();
    if (ruName.length() != 0 && enName.length() != 0) {
        Airport airport(0, enName, ruName);
        m_airports->Add(airport);
        ui->ruName_inp->clear();
        ui->enName_inp->clear();
        emit added();
    }
}

