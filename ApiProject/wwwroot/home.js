
async function start() {
    const n = document.getElementById("myName").value;
    const p = document.getElementById("myPassword").value;
    const url = `https://localhost:44368/Api/User/?email=${n}&password=${p}`;
    const ans = await fetch(url);
    if (ans.ok) {
        const ans2 = await ans.json();
 
        alert("ברוך הבא " + ans2[0].name);
        sessionStorage.setItem('details', JSON.stringify(ans2));
        window.location.href = "products.html";
    }

    else if (ans.status == 404) {
        let x = confirm("  משתמש לא קיים במערכת, האם ברצונך להרשם?");
    }
    else {
        window.location.href = "error.html";
    }
  
}
async function newUser() {
    const n = document.getElementById("name").value;
    const p = document.getElementById("password").value;
    const e = document.getElementById("email").value;
    if (nameValidations(n) && passwordValidation(p) && emailValidation(e)) {
        newUser = { "id": 0, "name": n, "password": p, "email": e };

        const res = await fetch("https://localhost:44368/Api/User",
            {
                headers: { "content-type": "application/json" },
                method: 'POST',
                body: JSON.stringify(newUser)
            })
        if (res.status == 201) {
            const theNewUser = await res.json()
            alert("נוסף בהצלחה למערכת  " + theNewUser.name)

        }
        else {
            alert("something went wrong");
            throw new Error("failed, please try later");
        }

    }
    function nameValidations (name){
        if (name.length > 100 || name.length < 2) {
            document.getElementById("nameValidation").innerText = "שם חייב להיות בין 2 ל100 תווים"
            return false;
        }
        return true;
    }
   function emailValidation(email) {
        if (email.indexOf("@") < 0 || email.indexOf(".") < email.indexOf("@") + 2) {
            document.getElementById("emailValidation").innerText = "כתובת מייל לא חוקית"
            return false;
        }
        return true;
    }
    async function passwordValidation(password) {
        var score = await checkPassword(password);
         if (await score < 3) {
            document.getElementById("passwordValidation").innerText = "סיסמא לא חזקה"
            return false;
        }
        return true;
    }

    async function checkPassword() {
        const password = document.getElementById("password").value;
        let url = "https://localhost:44368/Api/Password";
        const res = await fetch(url,
            {
                headers: { "content-type": "application/json" },
                method: 'POST',
                body: JSON.stringify(password)
            })
        if (res.ok) {
            let res2 = await res.json();
            alert(res2);
        }
        return res2;

    }
}
