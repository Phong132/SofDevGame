#Names: Chad Kessler, Cristian Mendivil, Ryan Bravdica, Nicholas Sugarman, Thomas Vu

#Title: 2D Platformer

#Vision:
Our vision is to create a memorable, simple, fun game by engaging gamers. We hope that our game captures the imaginations of experienced gamers and new gamers alike.

#Automated Tests: 
#Tool used:
Unity Test Tools
https://www.assetstore.unity3d.com/en/#!/content/13802

#Explanation: 
Unity Test Tools is an asset available for use from other Unity Developers. It allows users to test Unity content and includes:
-Unit Test Framework
-Integration Test Framework
-Assertion Component
-Integrated IDE, batch mode runners and integration tests player runner

In our specific tests, we ran an assertion test that allows us to monitor the physics of objects as they happen in game time. This can notify us automatically if, as in our test, a box is not properly bouncing and falling under the conditions we have set. In our test, it is set to “fail” every time the box collides, bounces, or interacts with other objects. By doing this, the console will show failures for the box in every instance that we assert the box will intersect (pass into/across/through) with another object. If we do not see “failures” (we are basically using them as flags) when we should, we know whatever just interacted with the box is not working in the matter we want.

We also ran an integration test (which uses call testing) as another example in order to see if any of our objects fall through, behind, or in front of our “ground” objects. This call testing functions to cause a failure any time ANY object falls through the ground. It also allows us to make sure that objects are under the correct effects of the gravity/drag we apply to them in game and that other physics are functioning accordingly. We can use them to pass or fail given certain conditions within a certain amount of time or even a certain number of frames.

#Screenshots of tests:

http://imgur.com/gallery/YyCaH



#User Acceptance Tests: 
Copy of at least three UAT plans

----------------------------------------------------------------------------------------------------------------------------------------
#Use Case Name: 

#Description: 

#Pre-conditions:

#Test Steps:

#Expected Result:

#Actual Result:

#Status (Pass/Fail):

#Notes:

#Post-Conditions:

----------------------------------------------------------------------------------------------------------------------------------------
#Use Case Name: 

#Description: 

#Pre-conditions:

#Test Steps:

#Expected Result:

#Actual Result:

#Status (Pass/Fail):

#Notes:

#Post-Conditions:

----------------------------------------------------------------------------------------------------------------------------------------
#Use Case Name: 

#Description: 

#Pre-conditions:

#Test Steps:

#Expected Result:

#Actual Result:

#Status (Pass/Fail):

#Notes:

#Post-Conditions:
