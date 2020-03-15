const assert = require('assert');
const { Given, When, Then } = require('cucumber');
const { Builder, By, Key, until } = require('selenium-webdriver');
const chrome = require('selenium-webdriver/chrome');
var {setDefaultTimeout} = require('cucumber');
var chai = require('chai')
expect = chai.expect
setDefaultTimeout(60 * 1000);

let driver
let vars
let title
let expectedTitle
driver = new Builder().forBrowser('chrome').build()
driver.manage().setTimeouts( { implicit: 1000000 } )
vars = {}

Given('O paciente acessa o guia médico da unimed', async function () {
    await driver.get("https://www.unimed.coop.br/")
    await driver.manage().window().maximize();
    await driver.findElement(By.css(".card:nth-child(2) .texto-midia")).click()
    await driver.findElement(By.id("campo_pesquisa")).click()
    expectedTitle = "Guia Médico Nacional Unimed - Institucional";
    title = await driver.getTitle()
    assert(title, expectedTitle)
  });  

When('O paciente pesquisa pela cidade do Rio de Janeiro', async function () {
    await driver.findElement(By.xpath("//div[@id=\'app\']/div/div/form/div/div/input")).sendKeys("Rio de Janeiro")
    await driver.findElement(By.id("btn_pesquisar")).click()
    await new Promise(r => setTimeout(r, 2000));
    expectedTitle = ""
    title = await driver.getTitle()
    assert(title, expectedTitle)
    await driver.findElement(By.id("react-select-2-input")).sendKeys("Rio de Janeiro")
    await driver.findElement(By.id("react-select-2-input")).sendKeys(Key.ENTER)
    await new Promise(r => setTimeout(r, 2000));
    await driver.findElement(By.id("react-select-3-input")).sendKeys("Rio de Janeiro")
    await driver.findElement(By.id("react-select-3-input")).sendKeys(Key.ENTER)
    await new Promise(r => setTimeout(r, 2000));
    await driver.findElement(By.xpath("//div[@id=\'app\']/div/div/div/div/div[2]/form/label/div/input")).click()
    await driver.findElement(By.css(".btn-success")).click()

});

Then('Os resultados dos médicos do Rio de Janeiro são apresentados', async function () {
    await new Promise(r => setTimeout(r, 8000));
    rioDeJaneiro = driver.findElement(By.xpath("(//p[text()='Barra Da Tijuca'])[1]")).getText();
    expect(rioDeJaneiro).to.have.string('Rio de Janeiro')
    await driver.quit();
    
});