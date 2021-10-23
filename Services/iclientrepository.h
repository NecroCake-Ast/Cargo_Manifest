#ifndef ICLIENTREPOSITORY_H
#define ICLIENTREPOSITORY_H
#include <string>
#include <vector>
#include "Models/client.h"

/// <summary>
/// Интерфейс классов, обрабатывающих данные о клиентах
/// </summary>
class IClientRepository
{
    /// <summary>
    /// Получение списка клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    virtual std::vector<Client> List() = 0;

    /// <summary>
    /// Добавление нового клиента
    /// </summary>
    /// <param name="client">Данные нового клиента</param>
    virtual void Add(const Client& client) = 0;

    /// <summary>
    /// Обновление данных о клиентах
    /// </summary>
    /// <param name="client">Новые данные</param>
    virtual void Update(const Client& client) = 0;

    /// <summary>
    /// Удаление информации о клиентах
    /// </summary>
    /// <param name="id">Код удаляемого клиента</param>
    virtual void Remove(const long long id) = 0;

    /// <summary>
    /// Возвращает ID клиента по его наименованию
    /// </summary>
    /// <param name="Name">Наименование клиента</param>
    /// <returns>ID клиента</returns>
    virtual long long FindByName(const std::string& Name) = 0;

    virtual ~IClientRepository() = 0;
};

#endif // ICLIENTREPOSITORY_H
