#include "servicelist.h"
#include "Debug/debugairportrepository.h"

IAirportRepository* ServiceList::_airportRepo = new DebugAirportRepository();

IAirportRepository *ServiceList::getAirportRepository()
{
    return _airportRepo;
}
