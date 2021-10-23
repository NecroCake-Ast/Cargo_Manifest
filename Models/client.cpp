#include "client.h"

void Client::setID(const int64_t id)
{
    m_ID = id;
}

void Client::setName(const std::string &name)
{
    m_Name = name;
}

void Client::setPhone(const std::string &phone)
{
    m_Phone = phone;
}

int64_t Client::getID() const
{
    return m_ID;
}

std::string Client::getName() const
{
    return m_Name;
}

std::string Client::getPhone() const
{
    return m_Phone;
}
