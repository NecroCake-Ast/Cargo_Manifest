#ifndef AIRPORTADDPAGE_H
#define AIRPORTADDPAGE_H

#include <QWidget>

#include "Services/iairportrepository.h"

namespace Ui {
class AirportAddPage;
}

class AirportAddPage : public QWidget
{
    Q_OBJECT

public:
    explicit AirportAddPage(QWidget *parent = nullptr);
    ~AirportAddPage();

signals:
    void added();

private slots:
    void on_add_btn_clicked();

private:
    Ui::AirportAddPage *ui;

    IAirportRepository* m_airports;
};

#endif // AIRPORTADDPAGE_H
