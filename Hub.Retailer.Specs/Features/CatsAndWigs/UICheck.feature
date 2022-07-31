Feature: C&I

@CATS&WIGS @HRP-2194
Scenario:  Create and complete Energy Offer then verify new NMI classifications value are added
	Given I login to user portal
	And I prepare energy offer data
		| Key                 | Value                       |
		| FunctionGroup       | Inbound Telesales - In-Situ |
		| OfferDocumentNumber | TR                          |
		| TrackingNumber      | TR_TEST                     |
	When I go to activity maintenance
	And I click Add button and go to activity 'Energy Offer' 'Energy Offer'
	And I create energy offer