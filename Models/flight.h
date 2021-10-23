#ifndef FLIGHT_H
#define FLIGHT_H
#include <string>


class Flight
{
    std::string m_CarrierCode;  //!< Код перевозчика
    std::string m_Number;       //!< Номер рейса
public:
    Flight(std::string CarrierCode, std::string Number)
        : m_CarrierCode(std::move(CarrierCode)), m_Number(std::move(Number)) {}

    void setCarrierCode(const std::string& value);
    void setNumber(const std::string& value);

    std::string getCarrierCode() const;
    std::string getNumber() const;

    std::string getFullName() const;
};

#endif // FLIGHT_H
