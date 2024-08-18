
import { useState } from "react";
import ProfileInput from "../Inputs/ProfileInput/ProfileInput";
import styles from "./ProfileInformation.module.css"
import BirthDayInput from "../Inputs/BirthDayInput/BirthDayInput";

const ProfileInformation = () => {
    const [userName, setUserName] = useState<string>("123");

    return (
        <div className={styles.container}>
            <p className={styles.sectionName}>Личные данные</p>
            <section>
                <ProfileInput label="Имя" btnAction={() => {}} btnName="Сохранить" value={userName} setValue={setUserName} />
            </section>
            <section>
                <ProfileInput label="Номер телефона" btnAction={() => {}} btnName="Сохранить" value={userName} setValue={setUserName} />
            </section>
            <section>
                <BirthDayInput/>
            </section>
            <section>
                <ProfileInput additionalInfrom="Сообщим о бонусах, акциях и новых продуктах" label="Эл. почта" btnAction={() => {}} btnName="Сохранить" value={userName} setValue={setUserName} />
            </section>
        </div>
    )
}

export default ProfileInformation;