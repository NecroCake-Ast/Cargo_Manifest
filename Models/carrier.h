#ifndef CARRIER_H
#define CARRIER_H
#include <string>


class Carrier
{
    std::string m_Code;  //!< Код перевозчика
    std::string m_Name;  //!< Наименование
    std::string m_Mail;  //!< Адрес электронной почты
public:
    Carrier(std::string Code, std::string Name, std::string Mail)
        : m_Code(std::move(Code)), m_Name(std::move(Name)), m_Mail(std::move(Mail)) {}

    void setCode (const std::string& value);
    void setName (const std::string& value);
    void setMail (const std::string& value);

    std::string getCode () const;
    std::string getName () const;
    std::string getMail () const;
};

#endif // CARRIER_H
