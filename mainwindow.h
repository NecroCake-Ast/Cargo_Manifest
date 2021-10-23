#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "Views/Airport/airportlistelement.h"
#include "Services/iairportrepository.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void on_navigation_currentChanged(int index);

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
