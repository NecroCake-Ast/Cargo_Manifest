#include <algorithm>
#include "debugairportrepository.h"

DebugAirportRepository::DebugAirportRepository()
{
    _data.emplace_back(1, "Р_1", "Е_1");
    _data.emplace_back(2, "Р_2", "Е_2");
    _data.emplace_back(3, "Р_3", "Е_3");
}

std::vector<Airport> DebugAirportRepository::List()
{
    return _data;
}

int64_t DebugAirportRepository::FindByName(const std::string &name)
{
    size_t idx = 0;
    while (_data[idx].getRuName() != name || _data[idx].getEnName() != name)
        idx++;
    return idx == _data.size() ? -1 : _data[idx].getID();
}

void DebugAirportRepository::Add(const Airport &airport)
{
    int64_t max = -1;
    for (const Airport& curAirport : _data)
        if (max < curAirport.getID())
            max = curAirport.getID();
    Airport temp(airport);
    temp.setID(max + 1);
    _data.push_back(temp);
}

void DebugAirportRepository::Update(const Airport &airport)
{
    size_t idx = 0;
    while (_data[idx].getID() != airport.getID())
        idx++;
    if (idx != _data.size())
        _data[idx] = airport;

}

void DebugAirportRepository::Remove(const int64_t id)
{
    auto idx = std::find_if(_data.begin(), _data.end(), [id](const Airport& val) { return val.getID() == id; } );
    if (idx != _data.end())
        _data.erase(idx);
}

Airport DebugAirportRepository::Get(const int64_t id)
{
    auto idx = std::find_if(_data.begin(), _data.end(), [id](const Airport& val) { return val.getID() == id; } );
    if (idx != _data.end())
        return *idx;
    return Airport(-1, "", "");
}
