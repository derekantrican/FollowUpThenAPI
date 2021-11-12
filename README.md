# FollowUpThenAPI


## Usage:

```csharp
FollowUpThenClient client = new FollowUpThenClient("TOKEN"); //See below for getting your token
client.CreateFollowUp("4pm", "This is a test subject");
```

_(More examples can be seen in the Demo project)_


## Getting your token:

1. Log in to https://app.followupthen.com
2. Open your browser's DevTools (Ctrl+Shift+J for chromium-based browsers)
3. Go to the "Network" tab, then refresh the page
4. Find the entry that starts with "tasks?..." and Method "GET"

![](https://i.imgur.com/MlD0eg5.png)

5. Click on that, then look for the line "Authorization: Bearer xxxxxxxxxxxx"
6. The alpha-numeric string after "Bearer" is your token

![](https://i.imgur.com/3fw46Pj.png)
