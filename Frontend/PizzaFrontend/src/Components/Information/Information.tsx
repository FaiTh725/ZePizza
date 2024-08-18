import { ReactNode, useEffect, useRef, useState } from "react";

import styles from "./Information.module.css"

import warning from "../../assets/WindowsTools/warning.png"

interface InformationProps {
    children: ReactNode,
    sizeImg: number 
}

const Information = ({children, sizeImg}: InformationProps) => {
    const [informationIsOpen, setInformationIsOpen] = useState(false);
    const informationRef = useRef<HTMLDivElement>(null);

    const handleClickOutSide = (e: MouseEvent) => {
        if(informationRef.current && !informationRef.current.contains(e.target as Node))
        {   
            setInformationIsOpen(false);
        }
    }

    useEffect(() => {
        if(informationIsOpen)
        {   
            document.addEventListener("mousedown", handleClickOutSide);
        }
        else 
        {
            document.removeEventListener("mousedown", handleClickOutSide);
        }

        return () => {
            document.removeEventListener("mousedown", handleClickOutSide);
        }
    }, [informationIsOpen]);

    return (
        <div ref={informationRef} className={styles.main}>
            <div onClick={() => setInformationIsOpen(!informationIsOpen)} className={styles.openInformation}>
                <img src={warning} alt="warning" width={sizeImg}/>
            </div>
            <div className={styles.informationContent+ ` ${informationIsOpen ? styles.open : styles.close}`}>
                {
                    children
                }
            </div>
        </div>
    )
}

export default Information;