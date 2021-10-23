#ifndef SERVICELIST_H
#define SERVICELIST_H
#include "iairportrepository.h"

class ServiceList
{
    static IAirportRepository* _airportRepo;
public:
    ServiceList() = delete;
    ServiceList(const ServiceList&) = delete;
    ServiceList(const ServiceList&&) = delete;

    static IAirportRepository* getAirportRepository();
};

#endif // SERVICELIST_H
