#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "Services/servicelist.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_navigation_currentChanged(int index)
{
    switch (index) {
        case 3:
            ui->airportsList->UpdateList();
            break;
    }
}

