var xValues1 = [100,200,300,400,500,600,700,800,900,1000];

new Chart("myChart1", {
  type: "line",
  data: {
    labels: xValues1,
    datasets: [{ 
      data: [860,1140,1060,1060,1070,1110,1330,2210,7830,2478],
      borderColor: "#6cc5f5",
      fill: false
    }, { 
      data: [1600,1700,1700,1900,2000,2700,4000,5000,6000,7000],
      borderColor: "#23b499",
      fill: false
    }, { 
      data: [300,700,2000,5000,6000,4000,2000,1000,200,100],
      borderColor:  "#0062be" ,
      fill: false
    }]
  },
  options: {
    legend: {display: false}
  }
});

var xValues = ["Học phí", "Khóa học", "Quản lý", ];
var yValues = [55, 49, 44];
var barColors = [
  "#b91d47",
  "#00aba9",
  "#2b5797",
 
];

new Chart("myChart", {
  type: "pie",
  data: {
    labels: xValues,
    datasets: [{
      backgroundColor: barColors,
      data: yValues
    }]
  },
  options: {
    title: {
      display: true,

    }
  }
});

var xValues2 = ["Lương", "Điện Nước", "Khác", ];
var yValues2 = [55, 49, 44];
var barColors = [
  "#b91d47",
  "#00aba9",
  "#2b5797",
 
];

new Chart("myChart12", {
  type: "pie",
  data: {
    labels: xValues2,
    datasets: [{
      backgroundColor: barColors,
      data: yValues2
    }]
  },
  options: {
    title: {
      display: true,

    }
  }
});