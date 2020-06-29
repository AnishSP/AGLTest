

Key Note
The provided AGL services is not online always.So if the output is not up on the console window,this might be an issue.

This Solution has two projects.
1. A Console application for sorting the Objects
2. A Unit test project with test cases


Notes

1.This project is based on .Net core framework
2.Project type used here is "Console Application"
3.Language used is C#
4.This project has been created using Visual Studio community Edition 2019 version 16.5.4
5.Target Framework - .Net core 3.1


Prerequisites/Dependencies

1. The given working URL is stored in a variable Utils\APIDetails.
2. This Service should be online and should provide the valid JSON.



Algorithm

1. Consume the API URL and extract the JSON 
2. The JSON is converted in to the List  with Objects Person and Pet (Person and Pets are class created based on the structure from JSON)
3. Create another List of objects with Pet Name and Owner Gender using the List of people. Referring the Model "PetNameWithOwnerGnder"
4. Group the List using the Owner gender and get two groups Male and Female.
5. Iterate through the List of groups and sort the List of pet Names in each group in alphabetical order
6. Once the Sort is done, the result is stored in a string variable with correct format
7. Print the Value in the variable.


Unit Test
Unit testing has been executed successfully for the different scenarios.
