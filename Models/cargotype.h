#ifndef CARGOTYPE_H
#define CARGOTYPE_H
#include <string>

class CargoType
{
    int64_t     m_ID;       //!< ID записи
    std::string m_EnName;   //!< Имя на английском
    std::string m_RuName;   //!< Имя на русском
public:
    CargoType(int64_t ID, std::string EnName, std::string RuName)
        : m_ID(ID), m_EnName(std::move(EnName)), m_RuName(std::move(RuName)) {}

    void setID(const int64_t id);
    void setEnName(const std::string& name);
    void setRuName(const std::string& name);

    int64_t getID() const;
    std::string getEnName() const;
    std::string getRuName() const;
};

#endif // CARGOTYPE_H
