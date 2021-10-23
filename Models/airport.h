#include <utility>

#ifndef AIRPORT_H
#define AIRPORT_H
#include <string>


class Airport
{
    int64_t     m_ID {};    //!< ID записи
    std::string m_EnName;   //!< Имя на английском
    std::string m_RuName;   //!< Имя на русском
public:
    Airport() : m_EnName(""), m_RuName("") {}
    Airport(int64_t id, std::string enName, std::string ruName)
        : m_ID(id), m_EnName(std::move(enName)), m_RuName(std::move(ruName)) {}

    void setID(const int64_t id);
    void setEnName(const std::string& name);
    void setRuName(const std::string& name);

    int64_t getID() const;
    std::string getEnName() const;
    std::string getRuName() const;
};

#endif // AIRPORT_H
