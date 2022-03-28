# FinalExamWebAPI

I decided to use only one controller "ParticipantControler.cs". 
It contains all the methods for the CRUD functionality, the Search functionality, and the Reporting functionality.

These are the ones that correspond to CRUD:

1. public IActionResult PostParticipant(string FirstName, string LastName, string Gender, DateTime BirthDate, string EmailAddress)
-> URL example in Insomnia: https://localhost:5001/api/Participant?FirstName=MEZ-juana&LastName=MEZ-Perez&Gender=F&BirthDate=1989-06-06&EmailAddress=mez-ana%40gmail.com

2. public IActionResult PutParticipant(int ParticipantId, Participant participant)
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/23

3.  public IActionResult DeleteParticipant(int ParticipantId)
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/103


These are the ones that correspond to Search:
1.   public IActionResult GetPArticipants() 
-> URL example in Insomnia: 
https://localhost:5001/api/participant

2.  public IActionResult FilteredParticipantsLastName(string LastName)
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/FilteredParticipantsLastName?LastName=as
 
3.   public IActionResult FilteredParticipantsEmailAddress(string EmailAddress)
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/FilteredParticipantsEmailAddress?EmailAddress=a%40

4. public IActionResult FilteredParticipantsBirthDate(DateTime BirthDate)
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/FilteredParticipantsBirthDate?BirthDate=1992-08-04


These are the ones that correspond to Reporting:
1. public IActionResult GetParticipantsByBirthDate()
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/ParticipantsByBirthDate

2. public IActionResult GetParticipantsByGender()
-> URL example in Insomnia: 
https://localhost:5001/api/Participant/ParticipantsByGender

As in the exam said "all participants" for both reports, for this last one, I took the liberty to create a method to return just "M" genders to have a little different code from the first one. To get ALL of them, is enough to delete the line 135 (.Where(p => p.Gender.Contains("M"))