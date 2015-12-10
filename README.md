# comic-calender-update
The program uses the Marvel API to search for comics by series, and returns a list of all the comics in the series. These comics release dates can then be added to
your Google calender.
A file will need to be created called keys.config next to the executable with the following format which needs 
your marvel public and private key. It will also need your google calender adress in the format "blahblah@group.calendar.google.com"

<appSettings>
  <add key="publicKey" value="" />
  <add key="privateKey" value="" />
  <add key="calenderAddress" value="" />
</appSettings>

TODO:
Other calender integration (.ics .vcs files etc.)
Better searching
Better GUI