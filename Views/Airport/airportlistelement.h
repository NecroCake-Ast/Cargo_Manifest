#ifndef AIRPOPTLISTELEMENT_H
#define AIRPOPTLISTELEMENT_H

#include <string>
#include <QWidget>
#include "../../Models/airport.h"

namespace Ui {
class AirportListElement;
}

class AirportListElement : public QWidget
{
    Q_OBJECT

public:
    explicit AirportListElement(const Airport& airport, QWidget *parent = nullptr);
    ~AirportListElement() override;

protected:
    void mousePressEvent(QMouseEvent *event) override;

private:
    Ui::AirportListElement *ui;
    Airport _data;

signals:
    void clickEvent(long long airportID);
};

#endif // AIRPOPTLISTELEMENT_H
