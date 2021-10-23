#ifndef IAIRPORTREPOSITORY_H
#define IAIRPORTREPOSITORY_H
#include <string>
#include <vector>
#include "Models/airport.h"

class IAirportRepository
{
public:
    /// <summary>
    /// Получение списка аэропортов
    /// </summary>
    /// <returns>Список аэропортов</returns>
    virtual std::vector<Airport> List() = 0;

    /// <summary>
    /// Поиск ID аэропорта по названию
    /// </summary>
    /// <param name="name">Название аэропорта</param>
    /// <returns>ID аэропорта, если он введён в систему, -1 в противном случае</returns>
    virtual int64_t FindByName(const std::string& name) = 0;

    /// <summary>
    /// Добавление нового аэропорта
    /// </summary>
    /// <param name="airport">Данные нового аэропорта</param>
    virtual void Add(const Airport& airport) = 0;

    /// <summary>
    /// Обновление данных о аэропорте
    /// </summary>
    /// <param name="airport">Новые данные</param>
    virtual void Update(const Airport& airport) = 0;

    /// <summary>
    /// Удаление информации о аэропорте
    /// </summary>
    /// <param name="id">Код удаляемого аэропорта</param>
    virtual void Remove(const int64_t id) = 0;

    /// <summary>
    /// Получение информации о аэропорте
    /// </summary>
    /// <param name="id">Код аэропорта</param>
    /// <return>Найденный аэропорт</return>
    virtual Airport Get(const int64_t id) = 0;

    virtual ~IAirportRepository() = default;
};

#endif // IAIRPORTREPOSITORY_H
