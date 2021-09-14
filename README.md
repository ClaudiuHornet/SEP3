# Via Pay


## Project scope

VIA University is in need of a system that manages transactions and payments within the members of the university.  The goal of the project is to design a software that will allow VIA to do so while developing a heterogeneous, three-tier system in the process.


### Team members:
- Maria Asenova
- Ionut Grosu
- Claudiu Hornet
- Cezary Korenczuk 


## Startup order

1. PersistenceLayer (C#)
2. ApplicationLogic (Java)
3. PresentationLayer (C#)

## Login credentials

### Admin 
Username: ***297111***

Password: ***CL88dHp***

### Member
Username: ***297112***

Password: ***Ck8WGN88***

### Facility
Username: ***12458***

Password: ***BiGlwiN9***


## Database seeding

Prerequisites: 
* Start PersistenceLayer
* Start ApplicationLogic

Send a `HTTP GET` request to http://localhost:8080/seeddatabase

This will empty the tables and input new data ready for testing purposes
