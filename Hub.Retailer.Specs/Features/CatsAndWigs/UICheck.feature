Feature: C&I

@CATS&WIGS @HRP-2194
Scenario:  Create and complete Energy Offer then verify new NMI classifications value are added
	Given I have utility type '<UtilityType>'
	And I have meter type '<MeterType>'
	And I have tariff '<Tariff>'
	And I have customer type '<CustomerType>'
	And I have address for state '<State>'
	And I have function group '<FunctionGroup>'
	And I have offer code 'ERST010'
	And I login to user portal
	When I go to activity maintenance
	And I click Add button and go to activity 'Energy Offer' 'Energy Offer'
	And I create energy offer

	Examples:
		| UtilityType | MeterType | Tariff | CustomerType | State | FunctionGroup               |
		| Electricity | Interval  | TAS61  | Residential  | TAS   | Inbound Telesales - In-Situ |
		| Electricity | Basic     | TAS22  | Residential  | TAS   | Inbound Telesales - In-Situ |