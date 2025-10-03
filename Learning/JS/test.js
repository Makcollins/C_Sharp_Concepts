let names = ["Collins", "Mathew", "Emmanuel", "John", "Alex", "Brian"]

function printNames() {
    let list = "<ul>";
    for (item of names) {
        list += "<li>" + item + "</li>"
    }
    list += "</ul>"
    document.getElementById("mnames").innerHTML = list;
}

function printNamesSorted() {
    let list = "<ul>";
    for (item of names.sort()) {
        list += "<li>" + item + "</li>"
    }
    list += "</ul>"
    document.getElementById("sorted_names").innerHTML = list;
}

function printNamesReverse() {
    let list = "<ul>";
    for (item of names.reverse()) {
        list += "<li>" + item + "</li>"
    }
    list += "</ul>"
    document.getElementById("sorted_reverse").innerHTML = list;
}

// let namesSorted = printList(names.sort());
// let namesReverse = printList(names.reverse());

function printList() {
    printNames();
    printNamesSorted();
    printNamesReverse();
}
// function printNames(){
//     // let text = "<ul>";
//     //     for (item of names) {
//     //         text += "<li>" + item + "</li>";
//     //     }
//     //     text += "</ul>";

//         document.getElementById("mnames").innerHTML = text;
// }

// let nameString = names.toString();

// printNames();
// console.log();
// printNames(names.reverse());
// console.log();
// console.log(nameString);
// console.log();
// console.log(names);
// console.log();
// printNames(names.sort());
