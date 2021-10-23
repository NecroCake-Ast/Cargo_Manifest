#ifndef DEBUGAIRPORTREPOSITORY_H
#define DEBUGAIRPORTREPOSITORY_H
#include "../iairportrepository.h"
#include "Models/airport.h"
#include "vector"

class DebugAirportRepository : public IAirportRepository
{
    std::vector<Airport> _data;
public:
    DebugAirportRepository();

    std::vector<Airport> List() final;
    int64_t FindByName(const std::string &name) final;
    void Add(const Airport &airport) final;
    void Update(const Airport &airport) final;
    void Remove(const int64_t id) final;
    Airport Get(const int64_t id) final;

    virtual ~DebugAirportRepository()= default;
};

#endif // DEBUGAIRPORTREPOSITORY_H
