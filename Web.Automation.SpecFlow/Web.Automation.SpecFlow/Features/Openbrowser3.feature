@Chrome
#@Firefox
Feature: Regiesteration Page 
Scenario Outline: Reg form
Given I am on Home page
	When enter "<firest_name>" into "First Name"
	And enter "<last_name>" into "Last Name"
	And enter "<mobile_number>" into "Mobile Number"
	And enter "<email>" into "Email"
	And enter "<password>" into "Password"
	And enter "<confirm_password>" into "Confirm Password"
	When  click on "Sign Up" Button 
	Then I Should see "<message>" message

	Examples: 
	| firest_name | last_name | mobile_number | email        | password | confirm_password | message                           |
	|             | Ahmed     | 0100002589    | test@tes.com | 123456   | 123456           | The First name field is required. |
	| Mohamed     |           | 0100002589    | test@tes.com | 123456   | 123456           | The Last Name field is required. |
	| Mohamed     | Ahmed     | 0100002589    |              | 123456   | 123456           | The Email  field is required. |
	| Mohamed     | Ahmed     | 0100002589    | test@tes.com |          | 123456           | The Password field is required. |
	| Mohamed     | Ahmed     | 0100002589    | test@tes.com | 123456   |                  | The Password field is required. |
	| Mohamed     | Ahmed     | 0100002589    | test@tes.com | 123456   | 123456            | Nothing Booked Yet              |


