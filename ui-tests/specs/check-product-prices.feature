Feature: As a user I expect the prices of products to be correct so that I don't get cheated.

    Scenario Outline: Verify that the product "<product>" are displayed when "Alla" is selected
        Given that I am on the product page
        When I choose the category "Alla"
        Then I should see the product "<product>"

        Examples:
            | product            |
            | Headphones         |
            | Smartphone         |
            | Laptop             |
            | Fiction Novel      |
            | Science Textbook   |
            | Mystery Book       |
            | T-shirt            |
            | Jeans              |
            | Jacket             |
            | Microwave Oven     |
            | Blender            |
            | Coffee Maker       |
            | Football           |
            | Tennis Racket      |
            | Yoga Mat           |


Scenario: Verify that specific products are displayed and incorrect products are not displayed when "Electronics" category is selected
    Given that I am on the product page
    When I choose the category "Electronics"
    Then I should see the product "Headphones"
    And I should see the product "Smartphone"
    And I should see the product "Laptop"
    And I should not see the product "Fiction Novel"
    And I should not see the product "Science Textbook"
    And I should not see the product "Mystery Book"
    And I should not see the product "T-shirt"
    And I should not see the product "Jeans"
    And I should not see the product "Jacket"
    And I should not see the product "Microwave Oven"
    And I should not see the product "Blender"
    And I should not see the product "Coffee Maker"
    And I should not see the product "Football"
    And I should not see the product "Tennis Racket"
    And I should not see the product "Yoga Mat"

Scenario: Verify that specific products are displayed and incorrect products are not displayed when "Books" category is selected
    Given that I am on the product page
    When I choose the category "Books"
    Then I should see the product "Fiction Novel"
    And I should see the product "Science Textbook"
    And I should see the product "Mystery Book"
    And I should not see the product "Headphones"
    And I should not see the product "Smartphone"
    And I should not see the product "Laptop"
    And I should not see the product "T-shirt"
    And I should not see the product "Jeans"
    And I should not see the product "Jacket"
    And I should not see the product "Microwave Oven"
    And I should not see the product "Blender"
    And I should not see the product "Coffee Maker"
    And I should not see the product "Football"
    And I should not see the product "Tennis Racket"
    And I should not see the product "Yoga Mat"

Scenario: Verify that specific products are displayed and incorrect products are not displayed when "Clothing" category is selected
    Given that I am on the product page
    When I choose the category "Clothing"
    Then I should see the product "T-shirt"
    And I should see the product "Jeans"
    And I should see the product "Jacket"
    And I should not see the product "Headphones"
    And I should not see the product "Smartphone"
    And I should not see the product "Laptop"
    And I should not see the product "Fiction Novel"
    And I should not see the product "Science Textbook"
    And I should not see the product "Mystery Book"
    And I should not see the product "Microwave Oven"
    And I should not see the product "Blender"
    And I should not see the product "Coffee Maker"
    And I should not see the product "Football"
    And I should not see the product "Tennis Racket"
    And I should not see the product "Yoga Mat"

Scenario: Verify that specific products are displayed and incorrect products are not displayed when "Sports" category is selected
    Given that I am on the product page
    When I choose the category "Sports"
    Then I should see the product "Football"
    And I should see the product "Tennis Racket"
    And I should see the product "Yoga Mat"
    And I should not see the product "Headphones"
    And I should not see the product "Smartphone"
    And I should not see the product "Laptop"
    And I should not see the product "Fiction Novel"
    And I should not see the product "Science Textbook"
    And I should not see the product "Mystery Book"
    And I should not see the product "T-shirt"
    And I should not see the product "Jeans"
    And I should not see the product "Jacket"
    And I should not see the product "Microwave Oven"
    And I should not see the product "Blender"
    And I should not see the product "Coffee Maker"

    Scenario: Display specific products with their prices when "Alla" is selected
    Given that I am on the product page
    When I choose the category "Alla"
    Then I should see that the product "Smartphone" and has the price "700 kr"
    And I should see that the product "Laptop" and has the price "1200 kr"
    And I should see that the product "Headphones" and has the price "150 kr"
    And I should see that the product "Fiction Novel" and has the price "15 kr"
    And I should see that the product "Science Textbook" and has the price "90 kr"
    And I should see that the product "Mystery Book" and has the price "20 kr"
    And I should see that the product "T-shirt" and has the price "20 kr"
    And I should see that the product "Jeans" and has the price "60 kr"
    And I should see that the product "Jacket" and has the price "120 kr"
    And I should see that the product "Microwave Oven" and has the price "100 kr"
    And I should see that the product "Blender" and has the price "50 kr"
    And I should see that the product "Coffee Maker" and has the price "80 kr"
    And I should see that the product "Football" and has the price "25 kr"
    And I should see that the product "Tennis Racket" and has the price "110 kr"
    And I should see that the product "Yoga Mat" and has the price "35 kr"


Scenario Outline: Verify that specific product <product> is displayed with correct price <price> and description <description> when "Alla" is selected
    Given that I am on the product page
    When I choose the category "Alla"
    Then I should see that the product "<product>", priced at "<price>", includes the description "<description>"

Examples:
    | product      | price | description                                         |
    | Smartphone   | 700 kr| High-end mobile phone with advanced features        |
    | Laptop       | 1200 kr| Portable computer suitable for all your tasks      |
    | Headphones   | 150 kr| Noise-cancelling headphones with high-quality sound |
    | Fiction Novel| 15 kr| A thrilling new release from a bestselling author    |
    | Science Textbook | 90 kr| Comprehensive guide to high school biology        |
    | Mystery Book | 20 kr| Engage in thrilling mystery solving adventures      |
    | T-shirt      | 20 kr| Comfortable cotton t-shirt available in various colors |
    | Jeans        | 60 kr| Durable and stylish jeans for everyday wear         |
    | Jacket       | 120 kr| Waterproof and windproof jacket ideal for all seasons |
    | Microwave Oven | 100 kr| Compact microwave oven for quick and easy meal preparation |
    | Blender      | 50 kr| Multi-function blender for smoothies, soups, and more |
    | Coffee Maker | 80 kr| Fast brewing coffee maker for a perfect morning cup |
    | Football     | 25 kr| Official size and weight football                    |
    | Tennis Racket| 110 kr| Lightweight racket for players of all skill levels  |
    | Yoga Mat     | 35 kr| Eco-friendly yoga mat with excellent grip           |




    Scenario: Check that Smartphone has the price 700 kr
        Given that I am on the product page
        When I choose the category "Electronics"
        Then I should see that the product "Smartphone" and has the price "700"


    Scenario: Check that Headphones has the price 150 kr
        Given that I am on the product page
        When I choose the category "Electronics"
        Then I should see that the product "Headphones" and has the price "150"

    Scenario: Check that I don't see Headphones in Books
        Given that I am on the product page
        When I choose the category "Books"
        Then I should not see the product "Headphones"
        And I should not see the product "Smartphones"

