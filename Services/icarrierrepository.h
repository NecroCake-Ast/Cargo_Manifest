#ifndef ICARRIERREPOSITORY_H
#define ICARRIERREPOSITORY_H
#include <string>
#include <vector>
#include "Models/carrier.h"

/// <summary>
    /// Интерфейс классов, обрабатывающих данные о перевозчиках
    /// </summary>
    class ICarrierRepository
    {
        /// <summary>
        /// Получение списка перевозчиков
        /// </summary>
        /// <returns>Список перевозчиков</returns>
        virtual std::vector<Carrier> List() = 0;

        /// <summary>
        /// Добавление нового перевозчика
        /// </summary>
        /// <param name="carrier">Данные нового перевозчика</param>
        virtual void Add(const Carrier& carrier) = 0;

        /// <summary>
        /// Обновление данных о перевозчике
        /// </summary>
        /// <param name="carrier">Новые данные</param>
        virtual void Update(const Carrier& carrier) = 0;

        /// <summary>
        /// Удаление информации о перевозчике
        /// </summary>
        /// <param name="code">Код удаляемого перевозчика</param>
        virtual void Remove(const std::string& code) = 0;

        virtual ~ICarrierRepository() = 0;
    };

#endif // ICARRIERREPOSITORY_H
