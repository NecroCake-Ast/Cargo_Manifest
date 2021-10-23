#ifndef AIRPORTEDITPAGE_H
#define AIRPORTEDITPAGE_H

#include <QWidget>

#include "Services/iairportrepository.h"

namespace Ui {
class AirportEditPage;
}

class AirportEditPage : public QWidget
{
    Q_OBJECT

public:
    explicit AirportEditPage(QWidget *parent = nullptr);
    ~AirportEditPage();

    void setActive(int64_t airportID);

signals:
    void removed();

private slots:
    void on_remove_btn_clicked();

    void on_enUpdate_btn_clicked();

    void on_ruUpdate_btn_clicked();

private:
    Ui::AirportEditPage *ui;

    Airport m_activeAirport;
    IAirportRepository* m_airports;
};

#endif // AIRPORTEDITPAGE_H
