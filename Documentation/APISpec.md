# GoalFund API Spec

This document outlines the resources and routes used in the GoalFund API. They will be defined here as created.

## Resources

**Quest**: A unit of work that a user will enter into the app. They will be able to assign a reward value to it that they can then redeem for rewards that they themselves set.

**Goal**: A reward that the user enters into the app. They decide on what scale to grade the point cost required to earn this item. Bear in mind that the app itself does nothing to actually stop the user from going out and buying things when they lack points. It is up to their own accountability and interest in improving their productivity. 

## Routes
`base/example/appendedVal`

**Request:**
```
{
    "Request": "Body"
}
```

**Response:**
```
{
    "Response": "Body"
}
```

**Exceptions:**

`4XX - User Error:` - The user did something wrong.