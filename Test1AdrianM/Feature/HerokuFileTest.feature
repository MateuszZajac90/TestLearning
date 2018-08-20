Feature: HerokuFileTest
	

@mytag
Scenario: Download any file from page
	Given Page to download file is opened
	When I click on any file to download it
	Then I checked that I download what I choose


Scenario: Upload any file on page
	Given Page to upload file is opened
	When I Upload file on page with name: 'NowyPlik'
	Then I checked that I upload file