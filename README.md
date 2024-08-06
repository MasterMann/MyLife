# MyLife

Cross-platform real life management tool.

**[!] Warning! Project is work-in-progress.**

## Screenshots

*Coming soon!*

## Features

- TODO: Add/remove/check, support for multiple lists;
- Notes: Google Keep-style quick notes;
- Services: Stuff automation, useful utilities;
- Spending: Track your spending, manage resources (wallet, cards, savings, etc.), get stats
- ...and more soon!

## Platforms & requirements

Client app:
- Windows 10 and later
- Linux (tested on Debian and derived distributions)
- Android (13 and later, WearOS 4 and later)

Server and infrastructure **(TBD)**:
- Windows 10 and later
- Linux (Docker Compose config included)
- CouchDB required (see supported version in *docker-compose.yml*)

## Building and running

*Detailed instructions coming soon!*

1. Clone repo to a local directory
2. Open MyLife.sln, select preferred platform-specific project:
	- Android: Android/MyLife.App.Android (mobile & watch)
	- Desktop: MyLife.App.Desktop
3. Build selected project and run
	- for Android, make sure to either have an emulator installed and AVD available, 
	  or connect a physical device to the development machine.