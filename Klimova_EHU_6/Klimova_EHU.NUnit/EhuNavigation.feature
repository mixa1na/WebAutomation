Feature: EHU Website Navigation
    As a website visitor
    I want to navigate through different sections of the EHU website
    So that I can find information about the university

Background:
    Given I am on the EHU homepage

Scenario: Complete user journey through EHU website
    When I switch language to Lithuanian
    Then I should be redirected to Lithuanian version
    When I navigate to About page
    Then I should see About page content
    When I search for "study programs"
    Then I should see search results
    When I navigate to Contact page
    Then I should see contact email address