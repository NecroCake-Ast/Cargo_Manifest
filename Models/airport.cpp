#include "airport.h"


void Airport::setID(const int64_t id)
{
    m_ID = id;
}

void Airport::setEnName(const std::string &name)
{
    m_EnName = name;
}

void Airport::setRuName(const std::string &name)
{
    m_RuName = name;
}

int64_t Airport::getID() const
{
    return m_ID;
}

std::string Airport::getEnName() const
{
    return m_EnName;
}

std::string Airport::getRuName() const
{
    return m_RuName;
}
