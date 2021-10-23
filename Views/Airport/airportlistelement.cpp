#include "airportlistelement.h"
#include "ui_airportlistelement.h"

AirportListElement::AirportListElement(const Airport& airport, QWidget* parent) :
    QWidget(parent),
    ui(new Ui::AirportListElement)
{
    _data = airport;
    ui->setupUi(this);
    QPalette Pal(palette());
    QColor clr(150, 150, 255);
    Pal.setColor(QPalette::Window, clr);
    ui->Background->setAutoFillBackground(true);
    ui->Background->setPalette(Pal);
    ui->Header->setText(QString::fromStdString(_data.getRuName()));
    QFont headerFont = ui->Header->font();
    headerFont.setPixelSize(24);
    ui->Header->setFont(headerFont);
    ui->Details->setText(QString::fromStdString(_data.getEnName()));
    QFont detailsFont = ui->Details->font();
    detailsFont.setPixelSize(16);
    ui->Details->setFont(detailsFont);
}

AirportListElement::~AirportListElement()
{
    delete ui;
}

void AirportListElement::mousePressEvent(QMouseEvent *event)
{
    emit clickEvent(_data.getID());
}
