const uri = 'api/Currencies';
let currencies = [];

function getCurrencies() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCurrencies(data))
        .catch(error => console.error("Not found", error));
}

function addCurrencies() {
    const addNameTextbox = document.getElementById('add-name');

    const currency = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(currency)
    })
        .then(response => response.json())
        .then(() => {
            getCurrencys();
            addNameTextBox.value = '';
        })
        .catch(error => console.error('Не вдалося додати жанр', error));
    document.getElementById('add-name').value = '';
}

function deleteCurrency(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCurrencys())
        .catch(error => console.error('Не вдалося видалити жанр'), error);
}

function displayEditForm(id) {
    const currency = currencies.find(currency => currency.id === id);

    document.getElementById('edit-id').value = currency.id;
    document.getElementById('edit-name').value = currency.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateCurrency() {
    const currencyId = document.getElementById('edit-id').value;
    const currency = {
        id: parseInt(currencyId, 10),
        name: document.getElementById('edit-name').value.trim()
    }

    fetch(`${uri}/${currencyId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(currency)
    })
        .then(() => getCurrencys())
        .catch(error => console.error('Не вдалось оновити жанр', error));

    closeInput();
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = none;
}

function _displayCurrencies(data) {
    const tBody = document.getElementById('currencies');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(currency => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${currency.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteCurrency(${currency.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(currency.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    currencies = data;
}