#include "airportlistpage.h"
#include "ui_airportlistpage.h"
#include "Services/servicelist.h"

AirportListPage::AirportListPage(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::AirportListPage)
{
    ui->setupUi(this);

    _airports = ServiceList::getAirportRepository();
    ui->ListLayout->setAlignment(Qt::AlignmentFlag::AlignTop);
    connect(ui->editPage, &AirportEditPage::removed, this, &AirportListPage::on_list_updated);
    connect(ui->addPage, &AirportAddPage::added, this, &AirportListPage::on_list_updated);
    UpdateList();
}

void AirportListPage::ClearList()
{
    for (size_t i = 0; i < _elements.size(); i++)
        if (_elements[i] != nullptr) {
            ui->ListLayout->removeWidget(_elements[i]);
            disconnect(_elements[i], &AirportListElement::clickEvent, this, &AirportListPage::onAirportSelect);
            delete _elements[i];
        }
    _elements.clear();
}

void AirportListPage::UpdateList()
{
    ClearList();
    std::vector<Airport> list = _airports->List();
    for(size_t i = 0; i < list.size(); i++) {
        AirportListElement* airport = new AirportListElement(list[i], this);
        connect(airport, &AirportListElement::clickEvent, this, &AirportListPage::onAirportSelect);
        _elements.push_back(airport);
        ui->ListLayout->addWidget(airport, static_cast<int>(i), 0);
        ui->ListLayout->setRowStretch(static_cast<int>(i), 0);
    }
}

AirportListPage::~AirportListPage()
{
    delete ui;
}

void AirportListPage::onAirportSelect(long long id)
{
    ui->editPage->setActive(id);
    ui->navigation->setCurrentIndex(1);
}

void AirportListPage::on_AddBtn_clicked()
{
    ui->navigation->setCurrentIndex(2);
}

void AirportListPage::on_list_updated()
{
    UpdateList();
    ui->navigation->setCurrentIndex(0);
}

void AirportListPage::on_editBack_btn_clicked()
{
    on_list_updated();
}

void AirportListPage::on_addBack_btn_clicked()
{
    on_list_updated();
}

