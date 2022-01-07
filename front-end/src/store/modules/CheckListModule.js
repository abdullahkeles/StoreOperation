// import {CheckList} from "@/models/CheckList";
// import {QuestionGroup} from "@/models/CheckListQuestionGroup";
// import {CheckListQuestion} from "@/models/CheckListQuestion";
// import {CheckListDay} from "@/models/CheckListDay";
// import {AppUser} from "@/models/AppUser";
import ApiService from "@/services/ApiService";

// const checkList = new CheckList(new Date(), [
//     new QuestionGroup(7012, "Hatırlatma", [
//         new CheckListQuestion(701201, "Sabah toplantısı yapıldı mı? Personele 6 kilit faktörün önemi hatırlatıldı mı?																						", false),
//         new CheckListQuestion(701202, "Birgün önceden kalan notların kontrolü yapıldı mı?																						", false),
//     ]),
//     new QuestionGroup(1011, "Mağaza Girişi Düzen ve Temizlik", [
//         new CheckListQuestion(101101, "AVM ve cadde mağazalarının dış cephedeki ışıklı tabelalarının sağlamlık kontrolü yapıldı mı?<span class=\"text--secondary\">(AVM mağazalarının dış cephe tabelası kontrol edilmeli)</span>", false),
//         new CheckListQuestion(101102, "Var ise fotoselli kapılar ve kepenkler sorunsuz çalışıyor mu?", false),
//         new CheckListQuestion(101103, "Kapı antenlerinin çalışır durumda olduğu kontrol edildi mi?", false),
//         new CheckListQuestion(101104, "Mağaza dezenfektan standı temiz ve dolu mu?", false),
//     ]),
//     new QuestionGroup(2012, "Mağaza İçi Düzen ve Temizli", [
//         new CheckListQuestion(201201, "Cadde mağazası iseniz tuvaletlerin kontrolü ve temizliği yapıldı mı? Temizlik malzemeleri (sabun, peçete, klozet kağıdı vb.) tam mı?", false),
//         new CheckListQuestion(201202, "Cadde mağazası iseniz jenaratörün kontrolü yapıldı mı? Yakıtı var mı?", false),
//         new CheckListQuestion(201203, "Cadde mağazası iseniz su giderlerinin kontrolü yapıldı mı?", false),
//         new CheckListQuestion(201204, "Yangın çıkışları ve elektrik odaları boş ve temiz mi?", false),
//         new CheckListQuestion(201205, "Ups çalışır durumda mı?", false),
//         new CheckListQuestion(201206, "Sayaç takip ekranında bir uyarı bulunuyor mu?", false),
//         new CheckListQuestion(201207, "Personel dinlenme/soyunma odaları ve arka ofis temiz ve düzenli mi?", false),
//         new CheckListQuestion(201208, "Motorola ve zebra yazıcıların şarjı dolu mu?", false),
//         new CheckListQuestion(201209, "Merdiven ve mağaza içi alanlar da boya-tadilat ihtiyacı var mı?", false),
//         new CheckListQuestion(201210, "Merdivenlerde kaydırmaz bant bulunuyor mu?", false),
//         new CheckListQuestion(201211, "Var ise yürüyen merdiven veya asansör çalışır durumda mı? İçi temiz mi?", false),
//         new CheckListQuestion(201212, "Var ise telsizler reyonlara dağıtıldı mı?", false),
//     ]),
//     new QuestionGroup(3012, "Görsel Düzen", [
//         new CheckListQuestion(301201, "Vitrin camları ve içi temiz mi? Işıkları çalışıyor mu?	", false),
//         new CheckListQuestion(301202, "Vitrin kurgusu mevcut sezona göre güncellenmiş mi? Vitrinde eksik ya da kırık aparat var mı?	", false),
//         new CheckListQuestion(301204, "Vitrin mankenlerinin, kombinlerinin ve vitrinlerin Mağazacılık Görsel Direktörlüğü tarafından gönderilen kurgulara uygunluğunun kontrolü yapıldı mı? 	", false),
//         new CheckListQuestion(301206, "Vitrinde olması gereken görseller mevcut mu(online alışveriş stickeri, mesam vb.)?	", false),
//         new CheckListQuestion(301207, "Vitrinlerde bulunan ürünlerin fiyatları doğru mu? 	", false),
//         new CheckListQuestion(301208, "Reyon yönlendirme tabelalarının sağlamlık kontrolü yapıldı mı?	", false),
//         new CheckListQuestion(301209, "Mağaza içi aydınlatmaların tümü çalışıyor mu? Açıları doğru mu?	", false),
//         new CheckListQuestion(301210, "İç imajların kontrolü yapıldı mı (yırtık, temizlik, güncellik ve eksik vb.)?	", false),
//         new CheckListQuestion(301211, "Stok kapağı imajlarının kontrolü yapıldı mı (yırtık, temizlik, güncellik ve eksik vb.)?	", false),
//         new CheckListQuestion(301212, "Mağaza duvar-ünite-masa dolukları Mağazacılık Görsel Direktörlük tarafından gönderilen strandartlara göre uygun seviyede mi? 	", false),
//         new CheckListQuestion(301213, "Katlanan tüm ürünler de beden etiketi uygulanmış mı?", false),
//         new CheckListQuestion(301214, "Görsel malzemelerin bulunduğu alanlar düzenli mi?", false),
//         new CheckListQuestion(301215, "Kampanya-indirim-özel uygulamalara ait görsel duyurular, pleksi, dönkartlar doğru noktalarda kullanıyor mu?", false),
//         new CheckListQuestion(301216, "Destinasyon alanlarında güncel duvar tip ve uygulamaları Görsel ve kapasite standartlarına göre yapılmış mı?", false),
//     ]),
//     new QuestionGroup(4012, "Satış Operasyon", [
//         new CheckListQuestion(401201, "Kabin içleri ve aynaları temiz mi? Kapı kolları sağlam mı?", false),
//         new CheckListQuestion(401202, "Kabin sepetliği boş mu? Üzerindeki meteryaller(askı,pleksi vb.) kaldırılmış mı?", false),
//         new CheckListQuestion(401204, "Reyonlar düzenli ve temiz mi? Temapos çevresi ve dolabı temiz mi?", false),
//         new CheckListQuestion(401206, "Mağaza koku cihazları çalışıyor mu? Cihaz yok ise reyonlara koku sıkıldı mı?", false),
//         new CheckListQuestion(401207, "Yangın tüplerinin pimi, basıncı ve tarihi kontrol edildi mi?", false),
//         new CheckListQuestion(401208, "Klimalar doğru sıcaklıkta ve çalışır durumda mı? Temizliği yapılmış mı?", false),
//         new CheckListQuestion(401209, "Alışveriş sepetlerinin tümü ünitelerinde/projede tanımlanan alanlarında ve düzenli mi? Eşit miktarlarda (20 adet) dağılmış mı?", false),
//         new CheckListQuestion(401210, "Personelin kıyafeti ve bakımı uygun mu?", false),
//     ]),
//     new QuestionGroup(5102, "Kasa Operasyon", [
//         new CheckListQuestion(501201, "Kasa noktası temiz ve düzenli mi? ", false),
//         new CheckListQuestion(501202, "Kasada bölgesindeki fiyat göstergeleri, yazıcılar ve kasalar çalışır durumda mı?", false),
//         new CheckListQuestion(501204, "Müzik sistemi ve kasa arkası TV'ler çalışır durumda mı?", false),
//         new CheckListQuestion(501206, "Kasa önü aksesuar üniteleri düzenli ve temiz mi?", false),
//         new CheckListQuestion(501207, "Kasa önü bariyer sistemi düzenli ve temiz mi?", false),
//         new CheckListQuestion(501208, "Kasa önü yönlendirme oklarının kontrolü yapıldımı? Kirli ise siparişi verildi mi?", false),
//         new CheckListQuestion(501209, "Var ise kasa numaratörleri aktif mi? Arıza bulunuyor ise çağrısı açılmış mı?", false),
//         new CheckListQuestion(501210, "Kasada poşet, rulo, fatura… vb. sarf malzemeler yeterli mi?", false),
//         new CheckListQuestion(501211, "Kasa bölgesinde bulunan banka kampanya görselleri güncel mi?", false),
//     ]),
//     new QuestionGroup(6012, "Depo Operasyon", [
//         new CheckListQuestion(601201, "Depo noktası düzenli ve temiz mi?", false),
//         new CheckListQuestion(601202, "Var ise depo reyon algoritması yok ise depoda olup reyonda olmayan ürün listesi kontrol edildi mi?	", false),
//         new CheckListQuestion(601206, "Müşteri talep ekranı kontrol edildi mi?", false),
//         new CheckListQuestion(601207, "Reyona acil çıkması gereken ürünler çıkartıldı mı?", false),
//     ]),
// ], 0, "");
// const checkListDays = [
//     new CheckListDay(1, 1, [new CheckList(new Date("2021-01-19T14:11:01"), null, 0, "sdfg", 1,new AppUser("Ali","Çalışkan"))], "01/01/2021T14:11:01", 0),
//     new CheckListDay(2, 2, [new CheckList(new Date("2021-01-20T08:02:01"), null, 0, "sdfg", 1,new AppUser("Veli","Koparan"))], "02/01/2021T08:02:01", 1),
//     new CheckListDay(3, 3, [new CheckList(new Date("2021-01-21T09:59:01"), null, 0, "sdfg", 1,new AppUser("Mehmet","Koşar"))], "03/01/2021T09:59:01", 2),
// ];

// new CheckGroup(7012, "Satış Operasyon", [
//     new CheckListQuestion(701204, "", false),
//     new CheckListQuestion(701206, "", false),
//     new CheckListQuestion(701207, "", false),
//     new CheckListQuestion(701208, "", false),
//     new CheckListQuestion(701209, "", false),
//     new CheckListQuestion(701210, "", false),
//     new CheckListQuestion(701211, "", false),
//     new CheckListQuestion(701212, "", false),
//     new CheckListQuestion(701212, "", false),
//     new CheckListQuestion(701212, "", false),
//     new CheckListQuestion(701212, "", false),
//     new CheckListQuestion(701212, "", false),
// ]),

const checkListModule = {
    state: {
        checkList: [],
        checkListDays: {},
        checkListQuestionGroups: [],
        checkListQuestionsInGroup: [],
    },
    getters: {
        getCheckList: (state) => {
            return state.checkList
        },
        getQuestionGroups: (state) => {
            return state.checkListQuestionGroups
        },
        getQuestionGroup: (state) => (QuestionGroupId) => {
            return state.checkList.QuestionGroups.find((item) => item.QuestionGroupId == QuestionGroupId)
        },
        getCheckListQuestionsInGroup: (state) => {
            return state.checkListQuestionsInGroup
        },
        getCheckListDays: (state) => {
            return state.checkListDays
        },
        getCheckListDaysStoreName: (state) => {
            if (state.checkListDays.store) {
                return state.checkListDays.store.storeName
            }
            return ''
        },
        getCheckListDay: (state) => (DayId) => {
            return state.checkListDays.find((x) => x.DayId == DayId)
        },
    },
    mutations: {
        updateCheckGroup(state, group) {
            let index = state.checkList.QuestionGroups.findIndex((x) => x.QuestionGroupId === group.QuestionGroupId)
            state.checkList.groups[index] = group
        },
        setCheckListDays(state, list) {
            state.checkListDays = list
        },
        setCheckList(state, list) {
            state.checkList = list
        },
        setQuestionGroups(state, groups) {
            state.checkListQuestionGroups = groups
        },
        setQuestionsInGroup(state, questions) {
            state.checkListQuestionsInGroup = questions
        }
    },
    actions: {
        updateCheckGroup({commit}, group) {
            commit('updateCheckGroup', group)
        },
        getCheckListDays({commit}) {
            ApiService.get('check-list/days')
                .then((days) => {
                        commit('setCheckListDays', days.data.data)
                    }
                )
        },
        getQuestionGroups({commit}) {
            ApiService.get('check-list/question-groups')
                .then((groups) => {
                        commit('setQuestionGroups', groups.data.data)
                    }
                )
        },
        createQuestionGroup(context, group) {
            return ApiService.post('check-list/question-group-create', group).then((group) => {
                return group.status
            })
        },
        updateQuestionGroup(context, group) {
            return ApiService.post('check-list/question-group-update', group).then((group) => {
                return group
            })
        },
        getCheckListQuestionInGroup(context, guid) {
            return ApiService.post('check-list/questions-in-group-get-all', {checkListQuestionGroupId: guid}).then((questions) => {
                return questions.data.data;
            });
        },
        createQuestion(context, model) {
            return ApiService.post('check-list/question-create', model)
        },
        createCheckList({commit}) {
            return ApiService.post('check-list/create').then((cl) => {
                commit('setCheckList', cl.data.data)
            });
        },
        addCheckList(context) {
            return ApiService.post('check-list/add', context.getters.getCheckList)
        },
        updateQuestion(context, model) {
            return ApiService.post('check-list/question-update', model)
        },
        reportCheckListStoreDay(context, dayId) {
            return ApiService.get('check-list/store-report-day?dayId=' + dayId)
        },
        reportCheckListAppStoresDays() {
            return ApiService.getWithParams('check-list/app-days-stores-report')
        },
        reportCheckListAppStoresDay(context,day) {
            console.log(day)
            return ApiService.getWithParams('check-list/app-day-stores-report', {day: day})
        }
    }
}

export default checkListModule


