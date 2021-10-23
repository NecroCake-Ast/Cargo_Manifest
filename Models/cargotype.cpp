#include "cargotype.h"

void CargoType::setID(const int64_t id)
{
    m_ID = id;
}

void CargoType::setEnName(const std::string &name)
{
    m_EnName = name;
}

void CargoType::setRuName(const std::string &name)
{
    m_RuName = name;
}

int64_t CargoType::getID() const
{
    return m_ID;
}

std::string CargoType::getEnName() const
{
    return m_EnName;
}

std::string CargoType::getRuName() const
{
    return m_RuName;
}
