#ifndef ICARGOTYPEREPOSITORY_H
#define ICARGOTYPEREPOSITORY_H
#include <string>
#include <vector>
#include "Models/cargotype.h"

/// <summary>
/// Интерфейс классов, обрабатывающих данные о товарах
/// </summary>
class ICargoTypeRepository
{
    /// <summary>
    /// Получение списка товаров
    /// </summary>
    /// <returns>Список товаров</returns>
    virtual std::vector<CargoType> List() = 0;

    /// <summary>
    /// Добавление нового товара
    /// </summary>
    /// <param name="cargotype">Данные нового товара</param>
    virtual void Add(const CargoType& cargotype) = 0;

    /// <summary>
    /// Обновление данных о товарах
    /// </summary>
    /// <param name="cargotype">Новые данные</param>
    virtual void Update(const CargoType& cargotype) = 0;

    /// <summary>
    /// Удаление информации о товарах
    /// </summary>
    /// <param name="id">Код удаляемого товара</param>
    virtual void Remove(const int id) = 0;

    /// <summary>
    /// Возвращает ID типа груза по названию
    /// </summary>
    /// <param name="Name"></param>
    /// <returns>ID типа груза</returns>
    virtual long long FindByName(const std::string& Name) = 0;

    virtual ~ICargoTypeRepository() = 0;
};

#endif // ICARGOTYPEREPOSITORY_H
