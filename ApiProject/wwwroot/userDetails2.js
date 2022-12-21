var details = JSON.parse(sessionStorage.getItem('details'));
var name = details[0].name;
var email = details[0].email;
var password = details[0].password;
let item;

function tmp() {
    item = document.getElementById("wellcom");
    item.innerHTML = `   שלום ל${name} אנו שמחים לשרת אותך `;
    //parent.appendChild(item);
    let n = document.getElementById('name');
    n.setAttribute("value", name);
    let n1 = document.getElementById('email');
    n1.setAttribute("value", email);
    let n2 = document.getElementById('password');
    n2.setAttribute("value", password);
    item.setAttribute("id", "wellcom");
    document.getElementById("wellcom").style.setProperty("display", "block");


}
tmp();
async function update() {

    const n = document.getElementById("name").value;
    const p = document.getElementById("password").value;
    const e = document.getElementById("email").value;
    user = { "id": details[0].id, "name": n, "password": p, "email": e };
    const res = await fetch(`https://localhost:44368/Api/User/${details[0].id}`, {
        headers: { "content-type": "application/json" },
        method: 'PUT',
        body: JSON.stringify(user)
    })
    if (res.ok)
        alert("עודכן בהצלחה");

}