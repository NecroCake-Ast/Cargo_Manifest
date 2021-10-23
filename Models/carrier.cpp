#include "carrier.h"

void Carrier::setCode(const std::string &value)
{
    m_Code = value;
}

void Carrier::setName(const std::string &value)
{
    m_Name = value;
}

void Carrier::setMail(const std::string &value)
{
    m_Mail = value;
}

std::string Carrier::getCode() const
{
    return m_Code;
}

std::string Carrier::getName() const
{
    return m_Name;
}

std::string Carrier::getMail() const
{
    return m_Mail;
}
