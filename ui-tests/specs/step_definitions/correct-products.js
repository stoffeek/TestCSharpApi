import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I am on the product page', () => {
  cy.visit('/products');
});

When('I choose the category {string}', (category) => {
  cy.get('#categories').select(category);
});

Then('I should see the product {string}', (productName) => {
  cy.get('.product .name').contains(productName);
});

Then('I should not see the product {string}', (productName) => {
  cy.get('.product .name').should('not.include.text', productName);
});

Then('I should see that the product {string} and has the price {string}', (productName, price) => {
  cy.get('.product').contains(productName).parent().within(() => {
    cy.get('.price').should('contain', `Pris: ${price}`);
  });
});

Then('I should see that the product {string}, priced at {string}, includes the description {string}', (productName, price, description) => {
  cy.get('.product').contains(productName).parent().within(() => {
    cy.get('.price').should('contain', price);
    cy.get('.description').should('contain', description);
  });
});

