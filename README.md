# Blazor-Teacher-Tools

A website of basic functionality for teachers in the classroom.

See it live at <https://tw-teacher-tools.firebaseapp.com>

Uses Blazor as a learning excersise, and experimenting with Progressive Web Apps.

## Publishing

1. Build the project:
```bash
dotnet publish -c Release
```

2. Publish to firebase
```bash
firebase deploy
```

The `firebase.json` ensures the correct build dir is used.

# License
MIT