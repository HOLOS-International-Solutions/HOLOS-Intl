# Holos Developer Guide

All text in the GUI must have an entry in a resource file. This enables the GUI to support multiple languages. Canada requires that all software interfaces support both official languages (English and French). Text that needs to be translated from English to French must be recorded in an online document shared with Holos collaborator:

https://docs.google.com/spreadsheets/d/1qKW-QNd9eCmvQP8VAPcQOgrb9fi_gqSGWFhmVh_JYLA/edit?usp=drive_link

## Prerequisites

To get started with HOLOS, you only need to install **Visual Studio 2022**. Visual Studio will automatically prompt you to download and install all the necessary prerequisites during the setup process.

### Visual Studio 2022 Installation

1. **Download Visual Studio 2022**:

   - Visit the [Visual Studio website](https://visualstudio.microsoft.com/downloads/) and download the Visual Studio 2022 installer.

2. **Install Visual Studio 2022**:

   - Run the installer.
   - During installation, select the **.NET Desktop Development** workload. If not selected then from the right side window select .NET 6.0/7.0/8.0 SDK. 
   - Then select **Visual Studio Extension Development.**
 These steps will ensure that you have everything you need to start and work with this project.

 ### Install Avalonia Extension

- After installing Visual Studio, open it and go to the **Extensions** menu.
- Select **Manage Extensions** and search for the **Avalonia for Visual Studo 2022** extension.
- Install the extension and restart Visual Studio.

### Set H.Avalonia as the Startup Project

- In the Solution Explorer, right-click on the `H.Avalonia` folder inside `H.GUI.Avalonia`.
- Select **Set as Startup Project** to ensure that the project is started properly.