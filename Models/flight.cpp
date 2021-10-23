#include "flight.h"

void Flight::setCarrierCode(const std::string &value)
{
    m_CarrierCode = value;
}

void Flight::setNumber(const std::string &value)
{
    m_Number = value;
}

std::string Flight::getCarrierCode() const
{
    return m_CarrierCode;
}

std::string Flight::getNumber() const
{
    return m_Number;
}

std::string Flight::getFullName() const
{
    return m_CarrierCode + m_Number;
}
