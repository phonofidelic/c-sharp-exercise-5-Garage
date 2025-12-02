# Garage 1.0

## Current project state
The application starts up as a console application and shows a main menu with selectable actions.
1. <b>Create new Garage</b>: re-initialize the garage with a new name and capacity (removes all current vehicles). 
2. <b>List parked vehicles</b>: displays a list of all vehicles currently parked in the garage.
3. <b>Park a new vehicle</b>: a form for entering vehicle details and parking the new vehicle in the garage.
4. <b>Remove a parked vehicle</b>: this is a mock section used in an early stage of the project when implementing th menu UI. Removing a parked vehicle could be implemented in the vehicles list view.

### Still to-do:
* Add more Vehicle types and explore co/contra-variance when displaying/filtering Vehicle in lists and performing opperations on Vehicles.
* Vehicles hava a uinique private _id member. Make sure multiple Vehicles with the same Id cannot exist in the Garage.
* Filter Vehicles list on different properties
* Remove vehicles from the Garage
* Get specific Vehicle by Id
* Add unit test
* Add saving application state to a json file
* Read and initialize application state from a json file
* Improve project structuer (add sub-sections within projects)

## Overview
Garage 1.0 consists of 3 projects:

1. [Garage](Garage)
2. [Garage.Library](Garage.Library)
3. [Garage.UI](Garage.UI)

<i>(Todo: add more info on project structure)</i>

## Garage
The main application project contains the Garage entities and UI implementation.

<i>(Todo: add more info on Garage project implementation)</i>

## Garage.Library
A supporting library project contains classes for implementing services and communication between services.

<i>(Todo: add more info on Garage services)</i>

## Garage.UI
A library for implementing a console menu UI.

<i>(Todo: add more info on Garage console UI components)</i>