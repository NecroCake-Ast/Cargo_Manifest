#ifndef CLIENT_H
#define CLIENT_H
#include <string>


class Client
{
    int64_t     m_ID;       //!< ID записи
    std::string m_Name;     //!< Наименование клиента
    std::string m_Phone;    //!< Номер телефона
public:
    Client(const int64_t ID, std::string Name, std::string Phone)
        : m_ID(ID), m_Name(std::move(Name)), m_Phone(std::move(Phone)) {}

    void setID(const int64_t id);
    void setName(const std::string& name);
    void setPhone(const std::string& phone);

    int64_t getID() const;
    std::string getName() const;
    std::string getPhone() const;
};

#endif // CLIENT_H
