#ifndef AIRPORTLISTPAGE_H
#define AIRPORTLISTPAGE_H

#include <QWidget>
#include "../../Services/iairportrepository.h"
#include "airportlistelement.h"

namespace Ui {
class AirportListPage;
}

class AirportListPage : public QWidget
{
    Q_OBJECT

public:
    explicit AirportListPage(QWidget *parent = nullptr);
    void ClearList();
    void UpdateList();
    ~AirportListPage();

private:
    Ui::AirportListPage *ui;

    IAirportRepository* _airports;

    std::vector<AirportListElement*> _elements;

private slots:
    void onAirportSelect(long long id);

    void on_AddBtn_clicked();
    void on_editBack_btn_clicked();
    void on_list_updated();
    void on_addBack_btn_clicked();
};

#endif // AIRPORTLISTPAGE_H
