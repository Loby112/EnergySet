const baseUrl = "https://energyrestapi20220607160027.azurewebsites.net/api/Energy"

Vue.createApp({
    data(){
        return{
            energyList: [],
            newData: {"energyMetric":"","value":null,"id":0},

        }
    }, 
    created(){
        this.getAllEnergyData()
    },
    methods: {
        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.energyList = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        getAllEnergyData(sort){
            let url = baseUrl
            if(sort == "Calorie"){
                url = baseUrl + "?sort=Calorie"
            }
            if(sort == "Joule"){
                url = baseUrl + "?sort=Joule"
            }
            this.helperGetAndShow(url)
        },

        async addEnergy(){
            try{
                const response = await axios.post(baseUrl, this.newData)
                this.getAllEnergyData()
                
            } catch (ex){
                alert(ex.message)
            }
        }

    }



}).mount('#app')